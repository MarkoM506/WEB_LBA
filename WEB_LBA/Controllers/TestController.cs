using System;
using System.Web.Mvc;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
using Emgu.CV.Face;
using System.Collections.Generic;
using Emgu.CV.Util;
using System.Linq;


namespace WEB_LBA.Controllers
{
    public class TestController : Controller
    {
        public string ProbarClasificador()
        {
            try
            {
                string xmlPath = Server.MapPath("~/App_Data/haarcascade_frontalface_default.xml");
                var faceDetector = new CascadeClassifier(xmlPath);

                if (faceDetector == null)
                    return "❌ Error: el clasificador no se inicializó correctamente.";


                return "✅ Clasificador cargado correctamente: " + xmlPath;
            }
            catch (Exception ex)
            {
                return "⚠️ Error al cargar clasificador: " + ex.Message;
            }
        }
        public ActionResult CapturarRostro()
        {
            try
            {
                // 1. Cargar clasificador de rostro
                string xmlPath = Server.MapPath("~/App_Data/haarcascade_frontalface_default.xml");
                var faceDetector = new CascadeClassifier(xmlPath);

                // 2. Iniciar la cámara (0 = cámara principal)
                using (var capture = new VideoCapture(0))
                {
                    // 3. Esperar un poco para estabilizar la cámara
                    System.Threading.Thread.Sleep(1000);

                    // 4. Capturar un frame (imagen)
                    using (var frame = capture.QueryFrame().ToImage<Bgr, byte>())
                    {
                        // 5. Convertir a escala de grises
                        var gray = frame.Convert<Gray, byte>();

                        // 6. Detectar rostros
                        var faces = faceDetector.DetectMultiScale(gray, 1.1, 10, Size.Empty);

                        // 7. Dibujar rectángulos sobre los rostros detectados
                        foreach (var face in faces)
                        {
                            frame.Draw(face, new Bgr(Color.Red), 3);
                        }

                        // 8. Guardar la imagen resultante
                       
                        string savePath = Server.MapPath("~/Content/Rostros/rostro_detectado.jpg");

                        frame.Save(savePath);

                        return Content($"✅ Imagen capturada y guardada en: {savePath} — Rostros detectados: {faces.Length}");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("⚠️ Error al capturar o detectar: " + ex.Message);
            }
        }
        public ActionResult RegistrarRostro(string nombreUsuario)
        {
            try
            {
                // 1. Crear carpeta para el usuario
                string carpetaUsuario = Server.MapPath($"~/Content/Entrenamiento/{nombreUsuario}");
                if (!Directory.Exists(carpetaUsuario))
                    Directory.CreateDirectory(carpetaUsuario);

                // 2. Cargar clasificador de rostro
                string xmlPath = Server.MapPath("~/App_Data/haarcascade_frontalface_default.xml");
                var faceDetector = new CascadeClassifier(xmlPath);

                // 3. Iniciar la cámara
                using (var capture = new Emgu.CV.VideoCapture())
                {
                    for (int i = 0; i < 20; i++) // Captura 20 imágenes
                    {
                        using (var frame = capture.QueryFrame().ToImage<Bgr, byte>())
                        {
                            if (frame == null) continue;

                            var gray = frame.Convert<Gray, byte>();
                            var faces = faceDetector.DetectMultiScale(gray, 1.1, 10, Size.Empty);

                            foreach (var face in faces)
                            {
                                var rostroRecortado = gray.Copy(face).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                                string fileName = Path.Combine(carpetaUsuario, $"rostro_{i + 1}.jpg");
                                rostroRecortado.Save(fileName);
                            }
                        }
                        System.Threading.Thread.Sleep(200); // espera entre capturas
                    }
                }

                return Content($"✅ Rostros registrados correctamente en {carpetaUsuario}");
            }
            catch (Exception ex)
            {
                return Content("❌ Error al registrar rostros: " + ex.Message);
            }
        }
        public ActionResult EntrenarModelo()
        {
            try
            {
                string rutaEntrenamiento = Server.MapPath("~/Content/Entrenamiento");
                string rutaModelo = Path.Combine(rutaEntrenamiento, "modeloLBPH.yml");

                var faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);

                List<Image<Gray, byte>> rostros = new List<Image<Gray, byte>>();
                List<int> etiquetas = new List<int>();
                int etiquetaActual = 0;

                // Recorre todas las carpetas de usuarios
                foreach (var carpetaUsuario in Directory.GetDirectories(rutaEntrenamiento))
                {
                    foreach (var archivo in Directory.GetFiles(carpetaUsuario, "*.jpg"))
                    {
                        var img = new Image<Gray, byte>(archivo).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                        rostros.Add(img);
                        etiquetas.Add(etiquetaActual);
                    }
                    etiquetaActual++;
                }

                // Convertir listas a estructuras que LBPHFaceRecognizer espera
                using (var vectores = new VectorOfMat(rostros.Select(r => r.Mat).ToArray()))
                using (var etiquetasVec = new VectorOfInt(etiquetas.ToArray()))
                {
                    faceRecognizer.Train(vectores, etiquetasVec);
                }

                // Guardar el modelo entrenado
                faceRecognizer.Write(rutaModelo);

                return Content($"✅ Modelo entrenado correctamente y guardado en: {rutaModelo}");
            }
            catch (Exception ex)
            {
                return Content("❌ Error al entrenar modelo: " + ex.Message);
            }
        }
        /*Este método:

        Lee todas las carpetas dentro de Entrenamiento.

        Usa las imágenes para entrenar un modelo LBPH.

        Guarda el modelo en un archivo llamado modeloLBPH.yml.*/
        public ActionResult VerificarRostro()
        {
            try
            {
                // 1️⃣ Cargar clasificador y modelo entrenado
                string xmlPath = Server.MapPath("~/App_Data/haarcascade_frontalface_default.xml");
                string modeloPath = Server.MapPath("~/Content/Entrenamiento/modeloLBPH.yml");

                var faceDetector = new CascadeClassifier(xmlPath);
                var faceRecognizer = new LBPHFaceRecognizer();
                faceRecognizer.Read(modeloPath);

                // 2️⃣ Capturar imagen desde la cámara
                using (var capture = new Emgu.CV.VideoCapture())
                using (var frame = capture.QueryFrame().ToImage<Bgr, byte>())
                {
                    if (frame == null)
                        return Content("⚠️ No se pudo capturar imagen desde la cámara.");

                    var gray = frame.Convert<Gray, byte>();
                    var rostros = faceDetector.DetectMultiScale(gray, 1.1, 10, Size.Empty);

                    if (rostros.Length == 0)
                        return Content("🚫 No se detectó ningún rostro.");

                    // 3️⃣ Verificar cada rostro detectado
                    foreach (var rostro in rostros)
                    {
                        var rostroRecortado = gray.Copy(rostro).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);

                        // 4️⃣ Predicción (comparación)
                        var resultado = faceRecognizer.Predict(rostroRecortado);

                        if (resultado.Label != -1 && resultado.Distance < 80) // umbral ajustable
                        {
                            return Content($"✅ Rostro reconocido correctamente. ID: {resultado.Label} (Distancia: {resultado.Distance:F2})");
                        }
                        else
                        {
                            return Content($"❌ Rostro no reconocido. (Distancia: {resultado.Distance:F2})");
                        }
                    }

                    return Content("⚠️ No se reconoció ningún rostro válido.");
                }
            }
            catch (Exception ex)
            {
                return Content("❌ Error en la verificación facial: " + ex.Message);
            }
        }
        /*
                 Carga el clasificador y el modelo entrenado(modeloLBPH.yml).

                Abre la cámara, toma una imagen.

                Detecta rostros en la imagen.

                Compara con el modelo entrenado.

                Si la distancia es baja(<80), se considera que el rostro coincide.
         */

        public ActionResult LoginFacial()
        {
            try
            {
                // 1️⃣ Cargar modelo y clasificador
                string xmlPath = Server.MapPath("~/App_Data/haarcascade_frontalface_default.xml");
                string modeloPath = Server.MapPath("~/Content/Entrenamiento/modeloLBPH.yml");

                var faceDetector = new CascadeClassifier(xmlPath);
                var faceRecognizer = new LBPHFaceRecognizer();
                faceRecognizer.Read(modeloPath);

                // 2️⃣ Capturar imagen desde la cámara
                using (var capture = new Emgu.CV.VideoCapture())
                using (var frame = capture.QueryFrame().ToImage<Bgr, byte>())
                {
                    if (frame == null)
                        return Content("⚠️ No se pudo capturar imagen desde la cámara.");

                    var gray = frame.Convert<Gray, byte>();
                    var rostros = faceDetector.DetectMultiScale(gray, 1.1, 10, Size.Empty);

                    if (rostros.Length == 0)
                        return Content("🚫 No se detectó ningún rostro.");

                    foreach (var rostro in rostros)
                    {
                        var rostroRecortado = gray.Copy(rostro).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                        var resultado = faceRecognizer.Predict(rostroRecortado);

                        // 3️⃣ Si la coincidencia es buena
                        if (resultado.Label != -1 && resultado.Distance < 80)
                        {
                            //  Marca la sesión como login facial válido
                            Session["LoginFacial"] = true;

                            //  Simula el rol administrativo (para que pase la validación del Panel)
                            Session["rol"] = "Administrativo";

                            //  Redirige al Panel Administrativo
                            return RedirectToAction("PanelAdministrativo", "Home");
                        }

                        else
                        {
                            return Content("❌ Acceso denegado: rostro no reconocido.");
                        }
                    }

                    return Content("⚠️ No se reconoció ningún rostro válido.");
                }
            }
            catch (Exception ex)
            {
                return Content("❌ Error en el login facial: " + ex.Message);
            }
        }



    }
}

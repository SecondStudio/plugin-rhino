using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using System.Diagnostics;
using System.Xml;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace Second_Studio
{
    [System.Runtime.InteropServices.Guid("494cf019-3a82-4081-848e-24f8a2a2b988")]
    public class SecondStudioCommand : Command
    {

        public SecondStudioCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static SecondStudioCommand Instance
        {
            get;
            private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "SecondStudio"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---

            Window my = new MainWindow();
            new System.Windows.Interop.WindowInteropHelper(my).Owner = Rhino.RhinoApp.MainWindowHandle();
            my.Show();

            return Result.Success;
           
        }

        
        public static Result GetOrigin()
        {
            
            Point3d pt0;
            //string origin = "0,0,0";
            EventModel _event = new EventModel();
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select your project's origin point");
                if(getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No origin point selected");
                    return getPointAction.CommandResult();
                }
                pt0 = getPointAction.Point();
                _event.Origin = pt0.ToString();

                string username = Environment.UserName;
                string directory = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio", username);
                System.IO.Directory.CreateDirectory(directory);
                string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\origin.xml", username);
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Origin");

                    writer.WriteElementString("Location", pt0.ToString());
                    

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                
            }

            
           
            RhinoApp.WriteLine(pt0.ToString());
            return Result.Success;
        }

        
        
        public static Result GetSpawn()
        {

            Point3d pt1;
           // string spawn = "0,0,0";
            
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select your character's spawn point");
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No spawn point selected");
                    return getPointAction.CommandResult();
                }
                pt1 = getPointAction.Point();
                //spawn = pt1.ToString();
                string username = Environment.UserName;
                string directory = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio", username);
                System.IO.Directory.CreateDirectory(directory);
                string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\spawn.xml", username);
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Spawn");

                    writer.WriteElementString("Location", pt1.ToString());


                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                

            }
            RhinoApp.WriteLine(pt1.ToString());
            return Result.Success;
        }

        public static Result ExportModel()
        {
            Rhino.FileIO.FileWriteOptions options = new Rhino.FileIO.FileWriteOptions();
            options.SuppressDialogBoxes = false;
            options.WriteSelectedObjectsOnly = false;
            

            options.IncludeRenderMeshes = true; // Save Small
            options.WriteGeometryOnly = false; // Geometry Only
            options.IncludeBitmapTable = true; // Save Texture

            string username = Environment.UserName;
            string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\world.fbx", username);
            bool result = RhinoDoc.ActiveDoc.WriteFile(path, options);
            RhinoApp.WriteLine("Model Exported!");

            return Result.Success;
        }

        


       
        
    }
}

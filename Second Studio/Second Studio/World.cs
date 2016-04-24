using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Second_Studio
{
    class World
    {
        string _name;
        string _origin;
        string _spawn;
        
        bool _fps;
        bool _dk1;
        bool _dk2;
        bool _cardboard;
        bool _gear;
        bool _vive;
        bool _morpheus;
        bool _magic;
        bool _architecture;
        bool _product;
        bool _fashion;
        bool _urban;
        bool _game;
        bool _film;
        bool _art;
        bool _sim;

        string _mat;
        string _tex;

        //,string origin,string spawn, string mode, string mat, string tex
        public World(string name, string origin, string spawn)
        {
            this._name = name;
            this._origin = origin;
            this._spawn = spawn;
        }

        public string Name { get { return _name; } }
        public string Origin { get { return _origin; } }
        public string Spawn { get { return _spawn; } }

        public static void Main()
        {
            //get vals from event model
            EventModel _event = new EventModel();
            World world = new World("name", _event.Origin, _event.Spawn);
            

            using (XmlWriter writer = XmlWriter.Create(@"C:\Users\Nels\Desktop\worlds.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("World");

                writer.WriteElementString("Name", world.Name);
                writer.WriteElementString("Date", System.DateTime.Now.ToString());
                writer.WriteElementString("Origin", world.Origin);
                writer.WriteElementString("Spawn", world.Spawn);

                writer.WriteEndElement();
                writer.WriteEndDocument();

            }
        }
        
    }
}

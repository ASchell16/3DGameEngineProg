using Client.GameObjects;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scripts
{
    public class WaypointFollowScript : ScriptComponent
    {
        public List<Vector3> Waypoints = new List<Vector3>();
        public int index= 0;
        public float Move = .5f;
        public bool AtLocation = false;

        public WaypointFollowScript(List<Vector3> locations) : base()
        {
            Waypoints = locations;
            
        }

        public override void Update()
        {

            for (int i = 0; i < Waypoints.Count; i++)
            {
                Owner.World = Matrix.CreateTranslation(Waypoints[index].X,
                                                       Waypoints[index].Y,
                                                       Waypoints[index].Z);
                if(index < Waypoints.Count )
                    index++;
                if (index > 2)
                    index = 0;
               
              
            }
            

            
         
                        

            base.Update();
        }


    }
}

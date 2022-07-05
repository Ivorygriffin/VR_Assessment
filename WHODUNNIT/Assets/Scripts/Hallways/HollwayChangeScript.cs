using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollwayChangeScript : MonoBehaviour
{



        public Hallway hallway;

        public Vector3 endAnchor;

        public float endAngle;



        public void ChangeHallwayAnchor()
        {

            hallway.endAnchor = (endAnchor);

            hallway.endAngle = (endAngle);

        }




    

}

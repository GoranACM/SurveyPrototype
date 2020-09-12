/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPrototype.SurveyEntities
{
    /// <summary>
    /// SSession is the object that represents the session that the survey respondent has
    /// </summary>
    public class SSession
    {
        public int sID { get; set; }
        public int rID { get; set; }

        // public bool sComplete { get; set; }
    }
}
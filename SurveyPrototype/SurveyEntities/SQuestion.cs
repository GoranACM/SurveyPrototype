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
    /// SQuestion is the object that represents the survey questions
    /// </summary>
    public class SQuestion
    {    
        public int qID { get; set; }
        public string qText { get; set; }
        public string qType { get; set; }
        public int? nQuestion { get; set; }
    }
}
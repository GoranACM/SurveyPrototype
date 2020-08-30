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
    /// SAnswerOptions is the object that represents the options in the survey answers
    /// </summary>
    public class SAnswerOptions
    {
        public int aOptionID { get; set; }
        public int aID { get; set; }
        public string aAnswerText { get; set; }
    }
}
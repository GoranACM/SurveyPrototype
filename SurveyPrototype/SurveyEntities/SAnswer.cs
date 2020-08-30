﻿/*  
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
    /// SAnswer is the object that represents the survey answers
    /// </summary>
    public class SAnswer
    {
        public int aID { get; set; }
        public int qID { get; set; }
        public int rID { get; set; }
    }
}
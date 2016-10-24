﻿using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace FitnessExercise.core
{
	public class Storage
	{
		public List<Exercise> toXML = new List<Exercise>();
		public List<String> fromXML = new List<String>();

		public void AddExercise(Exercise exercise) => this.toXML.Add(exercise);

		public void SaveXML()
		{
			var root = new XElement("Exercises");

			foreach (Exercise ex in toXML)
			{
				var child = new XElement("Exercise", "SOLO TEXTO");

				child.Add(new XAttribute("Name", ex.Name));
				child.Add(new XAttribute("Meters", ex.Meters));
				child.Add(new XAttribute("Minutes", ex.Minutes));
				child.Add(new XAttribute("Date", ex.Date.ToString()));

				root.Add(child);
			}
			root.Save("exercises.xml");
		}

		public void LoadXML()
		{
			if (File.Exists("exercises.xml"))
			{
				var root = XElement.Load("exercises.xml");

				IEnumerable<String> ex = from e in root.Elements("Exercise") select (String)e;

				foreach (String e in ex)
				{
					Console.WriteLine(e); //No está mostrando nada pq muestra el texto, no los atributos
				}
			}
		}
	}
}
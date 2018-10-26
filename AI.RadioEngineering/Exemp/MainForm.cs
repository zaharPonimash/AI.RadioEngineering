/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 23.10.2018
 * Время: 10:14
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AI.MathMod;
using AI.RadioEngineering;
using AI.MathMod.Signals;
using System.Threading;

namespace Exemp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			
			double t = 0.002, fd = 4e+4;
			Random rnd = new Random(10);
			
			int n = 640;
			Vector[] ch = new Vector[n];

			for (int i = 0; i < n; i++) 
			{
				ch[i] = Signal.LFM(1000, 7*(i+1), fd, t);
			}
			
			
			
			var sig = new Signal1D( ch, fd);
			
			//MessageBox.Show("Коэф. связи каналов: "+ sig.CouplingCoefficient());
			
			//MessageBox.Show("Коэф. связи амплитудных спектров: "+ sig.CouplingCoefficientSp());
			
			sig.CorrelationMatrixSpectr().MatrixShow();
		}
		
		
		
	}
}

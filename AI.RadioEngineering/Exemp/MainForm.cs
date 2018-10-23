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
			
			double t = 0.1, fd = 4e+4;
			
			Signal1D sig = new Signal1D
			(
				new Vector[]
				{
					Signal.LFM(9700, 0,     fd, t),
					Signal.LFM(700,  0,     fd, t),
					Signal.LFM(700,  800,   fd, t),
					Signal.LFM(700,  1800,  fd, t),
					Signal.LFM(1700, 800,   fd, t),
					Signal.LFM(600,  5800,  fd, t),
					Signal.LFM(1700, 8000,  fd, t)
				}
				, fd
			);
			
			//sig.VisualAmplSpectr();
			sig.CorrelationMatrixSpectr().MatrixShow();
			//sig.CorrelationMatrix().MatrixShow();
		}
		
		
		
	}
}

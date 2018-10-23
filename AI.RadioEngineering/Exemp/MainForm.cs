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
			
			Vector vect = Signal.LFM(1400, 0, 100000, 0.005);
			
			Signal1D sig = new Signal1D(vect, 100000);
			
			sig.Visual();
			
		}
		
		
		
	}
}

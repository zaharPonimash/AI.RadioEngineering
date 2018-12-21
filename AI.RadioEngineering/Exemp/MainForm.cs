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
			
			OFDM ofdm = new OFDM(3, 200);
			
			int N = 100;
			
			Vector vect = new Vector(N);
			Random rnd = new Random();
			
			for (int i = 0; i < N; i++)
			{
				vect[i] = rnd.NextDouble()>0.5? 1: 0;
			}
			
			vect.Visual();
			
			Vector[] s = ofdm.Seq2Parallel(vect);
			s = ofdm.Par2SigPar(s);
			
			
			
			Signal1D sig = new Signal1D(s, 10);
			sig.VisualSignal();
			
			
			Vector si = ofdm.BuldOfdmSig(s);
			si.Visual();
			ofdm.OutSig(si).Visual();
		}
		
		
		
	}
}

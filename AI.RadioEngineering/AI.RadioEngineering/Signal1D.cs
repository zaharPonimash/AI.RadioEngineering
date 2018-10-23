/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 23.10.2018
 * Время: 9:50
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using AI.MathMod;
using AI.MathMod.AdditionalFunctions;
using AI.MathMod.Signals;
using AI.MathMod.Graphiks;

namespace AI.RadioEngineering
{
	/// <summary>
	/// Основной класс для одномерного сигнала
	/// </summary>
	public class Signal1D
	{
		/// <summary>
		/// Частота дискретизации
		/// </summary>
		public double Fd{get; set;}
		
		/// <summary>
		/// Шаг по времени
		/// </summary>
		public double Dt
		{
			get
			{
				return 1.0/Fd;
			}
		}
		
		/// <summary>
		/// Каналы сигнала
		/// </summary>
		public Vector[] Channels{get; private set;}
		
		
		/// <summary>
		/// Инициализация многоканальным сигналом
		/// </summary>
		/// <param name="channels">Сигнал</param>
		/// <param name="fd">Частота дискретизации</param>
		public Signal1D(Vector[] channels, double fd)
		{
			Fd = fd;
			Channels = channels;
		}
		
		
		/// <summary>
		/// Инициализация многоканальным сигналом
		/// </summary>
		/// <param name="signal">Сигнал</param>
		/// <param name="fd">Частота дискретизации</param>
		public Signal1D(Vector signal, double fd)
		{
			Fd = fd;
			Channels = new Vector[]{signal};
		}
		
		
		/// <summary>
		/// Генерация отсчетов времени
		/// </summary>
		/// <returns>Отсчеты времени</returns>
		public Vector Time()
		{
			double endT = Channels[0].N/Fd;
			return MathFunc.GenerateTheSequence(0, Dt, endT).CutAndZero(Channels[0].N);
		}
		
		/// <summary>
		/// Генерация отсчетов частоты
		/// </summary>
		/// <returns>Отсчеты частоты</returns>
		public Vector Freq()
		{
			return Signal.Frequency(Channels[0].N, Fd).CutAndZero(Channels[0].N);
		}
		
		
		
		/// <summary>
		/// Визуализация
		/// </summary>
		public void Visual()
		{
			Descrintion desc = new Descrintion("Время [c]", "s(t) [В]", "Сигнал");
			Vector t = Time();
			
			for(int i = 0; i < Channels.Length; i++)
			{
				Channels[i].Visual(t, desc);
			}
			
		}
		
	}
}
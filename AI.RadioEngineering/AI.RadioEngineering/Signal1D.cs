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
		
		Furie fur;
		
		int _n;
		
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
			fur = new Furie(channels[0].N);
			_n = fur._n;
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
			fur = new Furie(signal.N);
			_n = fur._n;
		}
		
		/// <summary>
		/// Рассчитывает спектр
		/// </summary>
		/// <param name="numCh">Номер канала</param>
		/// <returns>Амплитудный спектр частоты 0 ... fd/2</returns>
		public Vector GetSpectr(int numCh = 0)
		{
			ComplexVector cv = fur.FFT(Channels[numCh]);
			Vector sp = cv.MagnitudeToVector()/_n;
			sp *= 2;
			sp = sp.CutAndZero(_n/2);
			return sp;
		}
		
		
		/// <summary>
		/// Рассчитывает спектр по всем каналам
		/// </summary>
		/// <returns>Спектры</returns>
		public Vector[] GetSpectrAll()
		{
			Vector[] vcs = new Vector[Channels.Length];
			
			for (int i = 0; i < Channels.Length; i++) 
			{
				vcs[i] = GetSpectr(i);
			}
			
			return vcs;
		}
		
		/// <summary>
		/// Корреляционная матрица по каналам
		/// </summary>
		/// <returns>Матрица</returns>
		public Matrix CorrelationMatrix()
		{
			return Matrix.CorrelationMatrixNorm(Channels);
		}
		
		
		/// <summary>
		/// Корреляционная матрица амплитудных спектров
		/// </summary>
		/// <returns>Матрица</returns>
		public Matrix CorrelationMatrixSpectr()
		{
			return Matrix.CorrelationMatrixNorm(GetSpectrAll());
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
			return Signal.Frequency(_n, Fd).CutAndZero(_n/2);
		}
		
		
		
		/// <summary>
		/// Визуализация сигнала
		/// </summary>
		public void VisualSignal()
		{
			Descrintion desc;
			Vector t = Time();
			
			for(int i = 0; i < Channels.Length; i++)
			{
				desc = new Descrintion("Время [c]", "s(t) [В]", "Сигнал [Канал №"+(i+1)+"]");
				Channels[i].Visual(t, desc);
			}
			
		}
		
		
		/// <summary>
		/// Визуализация спектра
		/// </summary>
		public void VisualAmplSpectr()
		{
			Descrintion desc;
			Vector f = Freq();
			
			for(int i = 0; i < Channels.Length; i++)
			{
				desc = new Descrintion("Частота [Гц]", "S(f) [В/Гц]", "Cпектр [Канал №"+(i+1)+"]");
				GetSpectr(i).Visual(f, desc);
			}
			
		}
		
	}
}
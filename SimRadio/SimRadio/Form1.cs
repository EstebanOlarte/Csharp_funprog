﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimRadio
{
    public partial class Form1 : Form
    {
        //atributo de la clase
        private Radio miRadio;

        //El constructor de la clase Form1
        public Form1()
        {
            InitializeComponent();

            //inicializamos nuestros atributos
            miRadio = new Radio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cuando el radio está apagado, nada se visualiza
            if (miRadio.Estado == false)
            {
                LabelFrecuencia.Text = "";
                LabelVolumen.Text = "";

                BotonFmas.Enabled = false;
                BotonFmenos.Enabled = false;
                BotonVmas.Enabled = false;
                BotonVmenos.Enabled = false;

                TrackVolumen.Enabled = false;
                TrackFrecuencia.Enabled = false;
                
                BotonEstado.BackColor = Color.Red;
                BotonEstado.Text = "Apagado";
            }
        }

        private void BotonEstado_Click(object sender, EventArgs e)
        {
            miRadio.CambiaEstado();

            //Cuando el radio está apagado, nada se visualiza
            if (miRadio.Estado == false)
            {
                LabelFrecuencia.Text = "";
                LabelVolumen.Text = "";

                BotonFmas.Enabled = false;
                BotonFmenos.Enabled = false;
                BotonVmas.Enabled = false;
                BotonVmenos.Enabled = false;

                TrackVolumen.Enabled = false;
                TrackFrecuencia.Enabled = false;

                BotonEstado.BackColor = Color.Red;
                BotonEstado.Text = "Apagado";
            }
            else
            {
                LabelFrecuencia.Text = miRadio.Frecuencia + "MHz";
                LabelVolumen.Text = miRadio.Volumen.ToString();

                TrackVolumen.Value = miRadio.Volumen;
                TrackFrecuencia.Value = (int)(miRadio.Frecuencia * 10);

                BotonFmas.Enabled = true;
                BotonFmenos.Enabled = true;
                BotonVmas.Enabled = true;
                BotonVmenos.Enabled = true;

                TrackVolumen.Enabled = true;
                TrackFrecuencia.Enabled = true;

                BotonEstado.BackColor = Color.Green;
                BotonEstado.Text = "Encendido";
            }
        }

        /// <summary>
        /// Evento que incrementa el volumen a través del botón  y visualiza el valor resultante
        /// </summary>
        private void BotonVmas_Click(object sender, EventArgs e)
        {
            miRadio.IncrementaVolumen();
            LabelVolumen.Text = miRadio.Volumen.ToString();
            TrackVolumen.Value = miRadio.Volumen;
        }

        /// <summary>
        /// Evento que decrementa el volumen a través del botón y visualiza el valor resultante
        /// </summary>
        private void BotonVmenos_Click(object sender, EventArgs e)
        {
            miRadio.DecrementaVolumen();
            LabelVolumen.Text = miRadio.Volumen.ToString();
            TrackVolumen.Value = miRadio.Volumen;
        }

        /// <summary>
        /// Evento que modifica el valor del volumen a través del TrackBar y visualiza el valor resultante
        /// </summary>
        private void TrackVolumen_Scroll(object sender, EventArgs e)
        {
            miRadio.Volumen = TrackVolumen.Value;
            LabelVolumen.Text = miRadio.Volumen.ToString();
        }

        /// <summary>
        /// Evento que incrementa el valor de la frecuencia actual a través del botón y visualiza el valor resultante
        /// </summary>
        private void BotonFmas_Click(object sender, EventArgs e)
        {
            miRadio.IncrementaFrecuencia();
            LabelFrecuencia.Text = miRadio.Frecuencia + " MHz";

            //Ajuste del valor del TrackFrecuencia
            TrackFrecuencia.Value = (int)(miRadio.Frecuencia * 10);
        }

        /// <summary>
        /// Evento que decrementa el valor de la frecuencia actual a través del botón y visualiza el valor resultante
        /// </summary>
        private void BotonFmenos_Click(object sender, EventArgs e)
        {
            miRadio.DecrementaFrecuencia();
            LabelFrecuencia.Text = miRadio.Frecuencia + " MHz";

            //Ajuste del valor del TrackFrecuencia
            TrackFrecuencia.Value = (int)(miRadio.Frecuencia * 10);
        }

        /// <summary>
        /// Evento que modifica el valor del volumen a través del TrackBar y visualiza el valor resultante
        /// </summary>
        private void TrackFrecuencia_Scroll(object sender, EventArgs e)
        {
            //Solo nos interesa el cambio cuando la frecuencia termina en *.9 MHz
            //Si el residuo de dividir por 10 da 9, nos sirve y hacemos la acción
            if ((float)(TrackFrecuencia.Value) % 10 == 9)
            {
                miRadio.Frecuencia = (float)(TrackFrecuencia.Value) / 10;
                LabelFrecuencia.Text = miRadio.Frecuencia.ToString() + " MHz";
            }
        }
    }
}

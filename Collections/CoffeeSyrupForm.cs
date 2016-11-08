﻿/*
 * Name : Anju Chawla
 * Date : November, 2016
 * Purpose: To allow the user to select coffee and syrup flavours.
 * New coffee flavours can be added and old ones removed. 
 * The entire coffee list can be cleared and number of coffee\flavours can be displayed.
 * Can print all available coffee flavours and only selected ones too.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collections
{
    public partial class CoffeeSyrupForm : Form
    {
        public CoffeeSyrupForm()
        {
            InitializeComponent();
        }

        private void printSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            //print selected flavours

            if (syrupListBox.SelectedIndex == -1)
            {
                syrupListBox.SelectedIndex = 0;
            }

            if (coffeeComboBox.SelectedIndex != -1)
            {
                printSelectedDocument.Print();
            }
            else
            {
                MessageBox.Show("Please select a coffee flavour", "Print Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }*/
        }

        private void previewSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (syrupListBox.SelectedIndex == -1)
            {
                syrupListBox.SelectedIndex = 0;
            }

            if (coffeeComboBox.SelectedIndex != -1)
            {
                printPreviewDialog1.Document = printSelectedDocument;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a coffee flavour", "Print Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                coffeeComboBox.Focus();
            }*/
        }

        private void printAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print all flavours
            printAllDocument.Print();

        }

        private void previewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //preview the coffee flavours
            printPreviewDialog1.Document = printAllDocument;
            printPreviewDialog1.ShowDialog();

        }

        private void printAllDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*
            // Handle printing and print previews when printing all.

            Font printFont = new Font("Arial", 12);
            float lineHeightFloat = printFont.Height + 2;
            float horizontalPrintLocationFloat = e.MarginBounds.Left;
            float verticalPrintLocationFloat = e.MarginBounds.Top;
            string printLineString;

            //Print the heading
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            e.Graphics.DrawString("Flavours", headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);

            // Loop through the entire list.
            //for (int ListIndexInteger = 0; ListIndexInteger < CoffeeComboBox.Items.Count - 1; ListIndexInteger++)
            foreach (Object flavor in coffeeComboBox.Items)
            {
                //increment the  Y position for the next line.
                verticalPrintLocationFloat += lineHeightFloat;

                //Set up a line
                //PrintLineString = CoffeeComboBox.Items[ListIndexInteger].ToString();
                printLineString = flavor.ToString();
                //Send the line to the graphics page object.
                e.Graphics.DrawString(printLineString, printFont,
                    Brushes.Black, horizontalPrintLocationFloat,
                    verticalPrintLocationFloat);
            } // end for
            */
        }

        private void printSelectedDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*
            // Handle printing and print previews when printing selected items.

            Font printFont = new Font("Arial", 12);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float lineHeightFloat = printFont.Height + 2;
            float horizontalPrintLocationFloat = e.MarginBounds.Left;
            float verticalPrintLocationFloat = e.MarginBounds.Top;
            string printLineString;

            //Set up and display heading lines
            printLineString = "Print Selected Item";
            e.Graphics.DrawString(printLineString, headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);
            printLineString = "by Anju Chawla";
            verticalPrintLocationFloat += lineHeightFloat;
            e.Graphics.DrawString(printLineString, headingFont,
                Brushes.Black, horizontalPrintLocationFloat,
                verticalPrintLocationFloat);

            // Leave a blank line between the heading and detail line.
            verticalPrintLocationFloat += lineHeightFloat * 2;
            // Set up the selected line.
            printLineString = "Coffee: " + coffeeComboBox.Text +
                "     Syrup: " + syrupListBox.Text;
            // Send the line to the graphics page object.
            e.Graphics.DrawString(printLineString, printFont,
                Brushes.Black, horizontalPrintLocationFloat,
                  verticalPrintLocationFloat);

    */
        }
    }
}

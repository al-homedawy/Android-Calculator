using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidCalculator
{
	[Activity (Label = "My Calculator", MainLauncher = true, Icon = "@drawable/icon")]
	public class MyClass : Activity
	{
		// Keep a record of both number variables
		private double numberOne = 0, numberTwo = 0;
		private int oneLen = 1, twoLen = 1;

		// This variable designates if we're on the first number
		// or second number
		private bool onSecond = false;

		// Designates if the user is adding decimal numbers
		private bool decimalNum = false;

		// This variable represents which operation the user has selected
		private int operation = -1;

		private void Equals ()
		{
			EditText text = FindViewById <EditText> (Resource.Id.editText);

			double result = 0;

			if (operation == 0)
				result = numberOne + numberTwo;
			else if (operation == 1)
				result = numberOne - numberTwo;
			else if (operation == 2)
				result = numberOne * numberTwo;
			else if (operation == 3)
				result = numberOne / numberTwo;
			else
				result = numberOne;

			text.Text = Convert.ToString (result);

			numberOne = result;
			numberTwo = 0;
			oneLen = 1;
			twoLen = 1;
			onSecond = false;
			decimalNum = false;
			operation = -1;
		}

		private void ChangeOp ( int op )
		{
			if (!onSecond) {
				decimalNum = false;
				onSecond = true;
				operation = op;
			} else {
				Equals ();
				operation = op;
				decimalNum = false;
				onSecond = true;
			}
		}

		private void UpdateNumber ( double number )
		{
			if ( !onSecond )
			{
				if (!decimalNum) {
					numberOne *= 10;
					numberOne += number;
				} else {
					double decNum = number;
					decNum *= Math.Pow ( Math.Pow ( 10, oneLen ), -1 );
					numberOne += decNum;
					++oneLen;
				}
			}
			else
			{
				if (!decimalNum) {
					numberTwo *= 10;
					numberTwo += number;
				} else {
					double decNum = number;
					decNum *= Math.Pow ( Math.Pow ( 10, twoLen ), -1 );
					numberTwo += decNum;
					++twoLen;
				}
			}

			// Update EditText
			EditText text = FindViewById <EditText> (Resource.Id.editText);

			String newText = Convert.ToString (numberOne);

			if (onSecond) {
				newText += " ";

				if (operation == 0)
					newText += "+";
				else if (operation == 1)
					newText += "-";
				else if (operation == 2)
					newText += "*";
				else
					newText += "/";

				newText += " ";
				newText += Convert.ToString (numberTwo);
			}

			text.Text = newText;
		}

		protected override void OnCreate ( Bundle bundle )
		{
			// Create the bundle
			base.OnCreate (bundle);

			// Set the main layout
			SetContentView (Resource.Layout.Main);

			// Declare the button's we'll be using
			Button button1 = FindViewById <Button> (Resource.Id.button1);
			Button button2 = FindViewById <Button> (Resource.Id.button2);
			Button button3 = FindViewById <Button> (Resource.Id.button3);
			Button button4 = FindViewById <Button> (Resource.Id.button4);
			Button button5 = FindViewById <Button> (Resource.Id.button5);
			Button button6 = FindViewById <Button> (Resource.Id.button6);
			Button button7 = FindViewById <Button> (Resource.Id.button7);
			Button button8 = FindViewById <Button> (Resource.Id.button8);
			Button button9 = FindViewById <Button> (Resource.Id.button9);
			Button button10 = FindViewById <Button> (Resource.Id.button10);
			Button button11 = FindViewById <Button> (Resource.Id.button11);
			Button button12 = FindViewById <Button> (Resource.Id.button12);
			Button button13 = FindViewById <Button> (Resource.Id.button13);
			Button button14 = FindViewById <Button> (Resource.Id.button14);
			Button button15 = FindViewById <Button> (Resource.Id.button15);
			Button button16 = FindViewById <Button> (Resource.Id.button16);
			Button button17 = FindViewById <Button> (Resource.Id.button17);
			Button button18 = FindViewById <Button> (Resource.Id.button18);

			// Assign the code for every button.
			button1.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 0.0d ); 
			};

			button2.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 1.0d );
			};

			button3.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 2.0d );
			};

			button5.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 3.0d );
			};

			button6.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 4.0d );
			};

			button7.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 5.0d );
			};

			button9.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 6.0d );
			};

			button10.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 7.0d );
			};

			button11.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 8.0d );
			};

			button13.Click += delegate(object sender, EventArgs e) {
				UpdateNumber ( 9.0d );
			};

			button4.Click += delegate(object sender, EventArgs e) {
				ChangeOp ( 0 );
			};

			button8.Click += delegate(object sender, EventArgs e) {
				ChangeOp ( 1 );
			};

			button12.Click += delegate(object sender, EventArgs e) {
				ChangeOp ( 2 );
			};

			button16.Click += delegate(object sender, EventArgs e) {
				ChangeOp ( 3 );
			};
			button14.Click += delegate(object sender, EventArgs e) {
				decimalNum = true;
			};
			button17.Click += delegate(object sender, EventArgs e) {
				numberOne = 0;
				numberTwo = 0;
				oneLen = 0;
				twoLen = 0;
				decimalNum = false;
				onSecond = false;
				operation = -1;

				EditText text = FindViewById <EditText> ( Resource.Id.editText );
				text.Text = "";
			};
			button15.Click += delegate {
				Equals ();
			};

			button18.Click += delegate {
				AlertDialog.Builder MsgBox = new AlertDialog.Builder ( this );
				MsgBox.SetMessage ( "Created by\n Hussain Al-Homedawy" );
				MsgBox.SetTitle ( "About" );
				MsgBox.SetNegativeButton ( "OK", delegate {} );
				MsgBox.Show ();
			};
		}
	}
}
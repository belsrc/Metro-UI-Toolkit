# Metro UI Toolkit
Metro UI Toolkit is a simple library of WPF controls that have a Modern/Metro UI look to them. I've also tried to expose several additional properties to make them quicker to customize (without having to build template sections) to hopefully decrease development time.

##MetroButton##
![alt Metro Button](http://bryanckizer.com/gitimg/button.png)  
_Inherits from Button_
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>DisabledBackground [Brush]</td>
        <td>The background color for the button's disabled state.</td>
    </tr>
    <tr>
    	<td>DisabledForeground [Brush]</td>
        <td>The foreground color for the button's disabled state.</td>
    </tr>
</table>  

##MetroComboBox##
![alt Metro Combo Box](http://bryanckizer.com/gitimg/combo-box.png)  
_Inherits from ComboBox_
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>ListBackground [Brush]</td>
        <td>The dropdown list background color.</td>
    </tr>
    <tr>
    	<td>ListForeground [Brush]</td>
        <td>The dropdown list foreground color.</td>
    </tr>
    <tr>
    	<td>ButtonHoverBackground [Brush]</td>
        <td>The button background color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>ButtonHoverForeground [Brush]</td>
        <td>The button foreground color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>SelectedBackground [Brush]</td>
        <td>The list item background color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SelectedForeground [Brush]</td>
        <td>The list item foreground color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SeperatorColor [Brush]</td>
        <td>The list item separator color.</td>
    </tr>
</table>  

##MetroDataGrid##
![alt Metro Data Grid](http://bryanckizer.com/gitimg/datagrid.png)  
_Inherits from DataGrid_  

##MetroListBox##
![alt Metro Listbox](http://bryanckizer.com/gitimg/Listbox.png)  
_Inherits from ListBox_
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>HoverBackground [Brush]</td>
        <td>The list item background color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>HoverForeground [Brush]</td>
        <td>The list item foreground color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>SelectedBackground [Brush]</td>
        <td>The list item background color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SelectedForeground [Brush]</td>
        <td>The list item foreground color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SeperatorColor [Brush]</td>
        <td>The list item separator color.</td>
    </tr>
</table>  

##MetroScollBar & MetroScrollViewer##
![alt Metro Scoll Bar](http://bryanckizer.com/gitimg/scroll-bar.png)  
_Inherits from ScrollBar and ScrollViewer respectively_  
<table>
    <tr>**Additional (ScrollBar) Properties**</tr>
    <tr>
    	<td>BarColor [Brush]</td>
        <td>The scrollbar's color.</td>
    </tr>
    <tr>
    	<td>ThumbColor [Brush]</td>
        <td>The scrollbar's thumb color.</td>
    </tr>
</table>  

##MetroTabItem##
![alt Metro Tab Control](http://bryanckizer.com/gitimg/tab-control.png)  
_Inherits from TabItem_  
<table>
    <tr>**Events**</tr>
    <tr>
    	<td>TabCloseClick [Bubble]</td>
        <td>Raised when the TabItem's close button is clicked.</td>
    </tr>
</table>  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>IsClosable [bool]</td>
        <td>Whether or not the close button is visible.</td>
    </tr>
</table>  

##MetroTextBox##
_Inherits from TextBox_  
![alt Metro Textbox](http://bryanckizer.com/gitimg/text-box.png) 
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>PlaceholderText [string]</td>
        <td>The text to display when the textbox is empty.</td>
    </tr>
</table>  

##MetroDatePicker##
![alt Metro Datepicker](http://bryanckizer.com/gitimg/datepicker.png)  
_Inherits from DatePicker_  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>CalendarIconColor [Brush]</td>
        <td>The calendar icon color.</td>
    </tr>
    <tr>
    	<td>CalendarIconHoverColor [Brush]</td>
        <td>The calendar icon hover color.</td>
    </tr>
    <tr>
    	<td>TodayBackground [Brush]</td>
        <td>Today's date background color.</td>
    </tr>
    <tr>
    	<td>SelectedBackground [Brush]</td>
        <td>The selected date background color.</td>
    </tr>
    <tr>
    	<td>HighlightBackground [Brush]</td>
        <td>The highlighted date background color.</td>
    </tr>
    <tr>
    	<td>CalendarForeground [Brush]</td>
        <td>The calendar dropdown's foreground color.</td>
    </tr>
    <tr>
    	<td>CalendarBackground [Color]</td>
        <td>The calendar dropdown's background color.</td>
    </tr>
    <tr>
    	<td>CalendarHeaderColor [Color]</td>
        <td>The calendar dropdown's header color.</td>
    </tr>
</table>  
<table>
    <tr>**Event Handlers**</tr>
    <tr>
    	<td>PreviewKeyDown</td>
        <td>The up and down arrow keys increment/decrement the selected date by one day.</td>
    </tr>
</table>  

##SearchBox##
![alt Metro Searchbox](http://bryanckizer.com/gitimg/search-box.png)  
_Inherits from ComboBox_  
<table>
    <tr>**Events**</tr>
    <tr>
    	<td>SearchClick [Bubble]</td>
        <td>Raised when the SearchBox's search button is clicked.</td>
    </tr>
</table>  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>PlaceholderText [string]</td>
        <td>The text to display when the searchbox is empty.</td>
    </tr>
    <tr>
    	<td>ListBackground [Brush]</td>
        <td>The dropdown list background color.</td>
    </tr>
    <tr>
    	<td>ListForeground [Brush]</td>
        <td>The dropdown list foreground color.</td>
    </tr>
    <tr>
    	<td>ButtonHoverBackground [Brush]</td>
        <td>The button background color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>ButtonHoverForeground [Brush]</td>
        <td>The button foreground color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>SelectedBackground [Brush]</td>
        <td>The list item background color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SelectedForeground [Brush]</td>
        <td>The list item foreground color while in the selected state.</td>
    </tr>
    <tr>
    	<td>SeperatorColor [Brush]</td>
        <td>The list item separator color.</td>
    </tr>
</table>  

##SelectPager##
![alt Modern Data Grid](http://bryanckizer.com/gitimg/select-pager.png)  
_Inherits from UserControl_  
<table>
    <tr>**Events**</tr>
    <tr>
    	<td>PageChanged [Bubble]</td>
        <td>Raised when the Pager's CurrentPage changes.</td>
    </tr>
</table>  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>DisabledBackground [Brush]</td>
        <td>The background color for the button's disabled state.</td>
    </tr>
    <tr>
    	<td>DisabledForeground [Brush]</td>
        <td>The foreground color for the button's disabled state.</td>
    </tr>
    <tr>
    	<td>CurrentPage [int]</td>
        <td>The current page.</td>
    </tr>
    <tr>
    	<td>PageCount [int]</td> 
        <td>The total number of pages.</td>
    </tr>
</table>  

##SimplePager##
![alt Modern Data Grid](http://bryanckizer.com/gitimg/simple-pager.png)  
_Inherits from UserControl_  
<table>
    <tr>**Events**</tr>
    <tr>
    	<td>PageChanged [Bubble]</td>
        <td>Raised when the Pager's CurrentPage changes.</td>
    </tr>
</table>  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>CurrentPage [int]</td>
        <td>The current page.</td>
    </tr>
    <tr>
    	<td>PageCount [int]</td>
        <td>The total number of pages.</td>
    </tr>
</table>  

##SlideCheck##
![alt Slide Check](http://bryanckizer.com/gitimg/check-sliders.png)  
_Inherits from UserControl_  

##WindowStateButtons##
![alt Window State Buttons](http://bryanckizer.com/gitimg/win-state-btns.png)  
_Inherits from UserControl_  
<table>
    <tr>**Events**</tr>
    <tr>
    	<td>MinimizeClick [Bubble]</td>
        <td>Raised when the minimize icon is clicked.</td>
    </tr>
    <tr>
    	<td>MaximizeClick [Bubble]</td>
        <td>Raised when the maximize icon is clicked.</td>
    </tr>
    <tr>
    	<td>NormalizeClick [Bubble]</td>
        <td>Raised when the normalize icon is clicked.</td>
    </tr>
    <tr>
    	<td>CloseClick [Bubble]</td>
        <td>Raised when the close icon is clicked.</td>
    </tr>
</table>  
<table>
    <tr>**Additional Properties**</tr>
    <tr>
    	<td>BackgroundHover [Brush]</td>
        <td>The icon background color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>ForegroundHover [Brush]</td>
        <td>The icon foreground color while in the hover-over state.</td>
    </tr>
    <tr>
    	<td>IsCloseVisible [bool]</td>
        <td>Whether or not the close button is visible.</td>
    </tr>
    <tr>
    	<td>IsMinimizeVisible [bool]</td>
        <td>Whether or not the minimize button is visible.</td>
    </tr>
    <tr>
    	<td>IsMaximizeVisible [bool]</td>
        <td>Whether or not the maximize button is visible.</td>
    </tr>
</table>   

## License ##
ModernUIControls is released under a BSD 3-Clause License

Copyright &copy; 2012-2013, Bryan Kizer
All rights reserved. 

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are 
met: 

* Redistributions of source code must retain the above copyright notice, 
  this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.
* Neither the name of the Organization nor the names of its contributors 
  may be used to endorse or promote products derived from this software 
  without specific prior written permission. 
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS 
IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED 
TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 

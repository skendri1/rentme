README

ADMIN username and password combinations (username,password)
	admin,password
	bill,gates
	steve,jobs
	ron,burgundy

EMPLOYEE username and password combinations (username,password)
	employee,password
	skendri1,pika
	drew,justus
	pac,irish
	monsters,inc
	herry,white

Steps to run the program.
	
	To use admin abilities: 
		Sign in using an admin username and password combo.

	To use employee abilities:
		sign in using an employee username and password combo.

	To select/search for a member:
		1. sign in as an employee
		2. click on the Member Search button near the top right of the window in the member information section
		3. input the criteria you have to find a member
		4. click on any cell in the row of the member you want to select.
			**You may have to click other cells in the same row until the window disappears for the member to be added 
			to the main screen. This is because of the cell click listener does not recognize a click all the time. 
		5. The selected member's information will be in the member information section at the top of the window.
			From here you can rent or return items depending on the transaction radio button you have selected.

	To search/select items:
		1. sign in as an employee
		2. make sure you are in rental mode
		3. At the bottom of the screen, in the search for items section, use the dropdown box to select your criteria type.
		4. Input your criteria into the search box and then click the search button to the right of the search text box.
		5. Upon clicking search, you will be given the search criteria's results in the grid box below it. 

	To Rent (an) item(s) to a customer:
		1. Sign in as an employee
		2. Make sure the Rental radio button is checked.
		3. Do the steps for select/search for a member (above this)
			*You could do this step after you have selected items to rent. Order does not really matter.
		4. Perform any necesarry searchs for items. See To Search/Select Items. (above)
		5. When both selected item grid and member info grids are filled, click the Rent button at the bottom right of the
			window. The system will then show a messagebox confirmation for the rental.

	To Return (an) item(s):
		1. Sign in as an employee
		2. Make sure the Return Radio button is checked (top left of the window)
		3. Perform a search/select for the Member that is returning items (See To select/search for a member)
		4. When you select a Member, the system will show the items they have rented that are not returned yet.
		5. Select the items they are returning.
		6. Click the return button to return the items.
		7. A confirmation will show with the total fee of their return.


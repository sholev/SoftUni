package bg.softuni.library.dto.lend;

import java.io.Serializable;
import java.sql.Date;

public class LendSearch implements Serializable {

	private static final long serialVersionUID = 1324705818913994987L;

	private String bookName;
	
	private String clientName;

	private Date lendDate;
	
	private Date returnDate;
	
	public String getBookName() {
		return bookName;
	}

	public String getClientName() {
		return clientName;
	}

	public Date getLendDate() {
		return lendDate;
	}

	public Date getReturnDate() {
		return returnDate;
	}

	public void setBookName(String bookName) {
		this.bookName = bookName;
	}

	public void setClientName(String clientName) {
		this.clientName = clientName;
	}

	public void setLendDate(Date lendDate) {
		this.lendDate = lendDate;
	}

	public void setReturnDate(Date returnDate) {
		this.returnDate = returnDate;
	}
	
	public boolean isNull() {
		return bookName == null 
				&& clientName == null 
				&& lendDate == null 
				&& returnDate == null;
	}
}

package bg.softuni.library.entities.lend;

import java.io.Serializable;
import java.sql.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="LIB_LENDS")
public class Lend implements Serializable, Comparable<Lend> {

	private static final long serialVersionUID = -1514677284262302501L;
	
	@Id
	@Column(name="ID")
	private Long id;

	@Column(name="BOOK_ID")
	private Long bookId;
	
	@Column(name="CLIENT_ID")
	private Long clientId;
	
	@Column(name="LEND_DATE")
	private Date lendDate;
	
	@Column(name="RETURN_DATE")
	private Date returnDate;

	public Long getId() {
		return id;
	}

	public Long getBookId() {
		return bookId;
	}

	public Long getClientId() {
		return clientId;
	}

	public Date getLendDate() {
		return lendDate;
	}

	public Date getReturnDate() {
		return returnDate;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setBookId(Long bookId) {
		this.bookId = bookId;
	}

	public void setClientId(Long clientId) {
		this.clientId = clientId;
	}

	public void setLendDate(Date lendDate) {
		this.lendDate = lendDate;
	}

	public void setReturnDate(Date returnDate) {
		this.returnDate = returnDate;
	}

	@Override
	public int compareTo(Lend other) {		
		return Long.compare(this.id, other.id);
	}
}

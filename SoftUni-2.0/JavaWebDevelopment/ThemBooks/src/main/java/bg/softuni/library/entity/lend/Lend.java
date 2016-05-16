package bg.softuni.library.entity.lend;

import java.io.Serializable;
import java.sql.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Transient;

import bg.softuni.library.entity.book.Book;
import bg.softuni.library.entity.client.Client;

@Entity
@Table(name="LIB_LENDS")
public class Lend implements Serializable, Comparable<Lend> {

	private static final long serialVersionUID = -1514677284262302501L;
	
	@Id
	@Column(name="ID")
	private Long id;

	@Column(name="BOOK_ID")
	private Long bookId;
	
	@Transient
	private Book book;
	
	@Column(name="CLIENT_ID")
	private Long clientId;
	
	@Transient
	private Client client;
	
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

	public Book getBook() {
		return book;
	}

	public Long getClientId() {
		return clientId;
	}

	public Client getClient() {
		return client;
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

	public void setBook(Book book) {
		this.book = book;
	}

	public void setClientId(Long clientId) {
		this.clientId = clientId;
	}

	public void setClient(Client client) {
		this.client = client;
	}

	public void setLendDate(Date lendDate) {
		this.lendDate = lendDate;
	}

	public void setReturnDate(Date returnDate) {
		this.returnDate = returnDate;
	}

	public String toUrl() {
		return "?id=" + id 
				+ "&bookId=" + bookId 
				+ "&clientId=" + clientId 
				+ "&lendDate=" + lendDate
				+ "&returnDate=" + returnDate;
	}
	
	@Override
	public int compareTo(Lend other) {		
		return Long.compare(this.id, other.id);
	}
}

package bg.softuni.library.entities.book;

import java.io.Serializable;
import java.sql.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "LIB_BOOKS")
public class Book implements Serializable, Comparable<Book> {

	private static final long serialVersionUID = 9105033794976854357L;

	@Id
	@Column(name="ID")
	private Long id;
	
	@Column(name="NAME")
	private String name;
	
	@Column(name="AUTHOR")
	private String author;
	
	@Column(name="PUBLISH_DATE")
	private Date publishDate;

	@Column(name="PAGES")
	private int pages;
	
	public Long getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getAuthor() {
		return author;
	}

	public Date getPublishDate() {
		return publishDate;
	}

	public int getPages() {
		return pages;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setAuthor(String author) {
		this.author = author;
	}

	public void setPublishDate(Date publishDate) {
		this.publishDate = publishDate;
	}

	public void setPages(int pages) {
		this.pages = pages;
	}

	@Override
	public int compareTo(Book other) {		
		return Long.compare(this.id, other.id);
	}

	public String toUrl() {
		return "?id=" + id
				+ "&name=" + name
				+ "&author=" + author
				+ "&publishDate=" + publishDate
				+ "&pages=" + pages;
	}
}

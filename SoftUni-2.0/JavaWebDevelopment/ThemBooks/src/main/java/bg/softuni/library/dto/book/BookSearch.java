package bg.softuni.library.dto.book;

import java.io.Serializable;
import java.sql.Date;

public class BookSearch implements Serializable {

	private static final long serialVersionUID = 9105033794976854357L;
	
	private String name;
	
	private String author;
	
	private Date publishDate;

	public String getName() {
		return name;
	}

	public String getAuthor() {
		return author;
	}

	public Date getPublishDate() {
		return publishDate;
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
}

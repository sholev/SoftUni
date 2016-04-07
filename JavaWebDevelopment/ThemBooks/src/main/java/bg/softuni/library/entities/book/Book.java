package bg.softuni.library.entities.book;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "LIB_BOOKS")
public class Book implements Serializable{

	private static final long serialVersionUID = 9105033794976854357L;

	@Id
	@Column(name="ID")
	private Long id;
	
	@Column(name="NAME")
	private String name;
	
	@Column(name="AUTHOR")
	private String author;
	
	@Column(name="PUBLISH_DATE")
	private Date date;
}

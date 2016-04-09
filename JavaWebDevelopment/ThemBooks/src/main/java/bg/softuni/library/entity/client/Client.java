package bg.softuni.library.entity.client;

import java.io.Serializable;
import java.sql.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="LIB_CLIENTS")
public class Client implements Serializable, Comparable<Client> {

	private static final long serialVersionUID = 8538303966847273069L;
	
	@Id
	@Column(name="ID")
	private Long id;
	
	@Column(name="NAME")
	private String name;
	
	@Column(name="PID")
	private String pid;
	
	@Column(name="BIRTH_DATE")
	private Date birthDate;

	public Long getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getPid() {
		return pid;
	}

	public Date getBirthDate() {
		return birthDate;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setPid(String pid) {
		this.pid = pid;
	}

	public void setBirthDate(Date birthDate) {
		this.birthDate = birthDate;
	}

	@Override
	public int compareTo(Client other) {		
		return Long.compare(this.id, other.id);
	}
	
	public String toUrl() {
		return "?id=" + id 
				+ "&name=" + name 
				+ "&pid=" + pid 
				+ "&birthDate=" + birthDate;
	}
}

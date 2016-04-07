package bg.softuni.library.entities.user;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity
@Table(name = "LIB_USERS")
public class User implements Serializable, Comparable<User> {

	private static final long serialVersionUID = 6791217416196444046L;

	@Id
	@Column(name = "ID")
	private Long id;
	
	@Column(name = "USERNAME")
	private String username;
	
	@Column(name = "PASSWORD")
	private String password;
	
	@Column(name = "STATUS")
	private String status;
	
	@Column(name = "NAME")
	private String name;
	
	@Transient
	private String roles;

	public Long getId() {
		return id;
	}

	public String getUsername() {
		return username;
	}

	public String getPassword() {
		return password;
	}
	
	public String getStatus() {
		return status;
	}

	public String getName() {
		return name;
	}
	
	public String getRoles() {
		return roles;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	
	public void setStatus(String status) {
		this.status = status;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setRoles(String roles) {
		this.roles = roles;
	}

	@Override
	public int compareTo(User other) {		
		return Long.compare(this.id, other.id);
	}
}

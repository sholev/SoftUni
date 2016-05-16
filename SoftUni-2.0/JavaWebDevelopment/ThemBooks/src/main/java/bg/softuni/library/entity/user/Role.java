package bg.softuni.library.entity.user;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "LIB_ROLES")
public class Role implements Serializable {

	private static final long serialVersionUID = -4433648756027091826L;

	@Id
	@Column(name="ID")
	private Long id;
	
	@Column(name="USER_ID")
	private Long userId;
	
	@Column(name="ROLE")
	private String role;
		
	public Role() {
	}
	
	public Role(Long id, Long userId, String role) {
		this.id = id;
		this.userId = userId;
		this.role = role;
	}

	public Long getId() {
		return id;
	}

	public Long getUserId() {
		return userId;
	}

	public String getRole() {
		return role;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setUserId(Long userId) {
		this.userId = userId;
	}

	public void setRole(String role) {
		this.role = role;
	}
}

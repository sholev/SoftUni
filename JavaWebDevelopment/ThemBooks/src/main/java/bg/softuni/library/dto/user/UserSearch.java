package bg.softuni.library.dto.user;

import java.io.Serializable;

public class UserSearch implements Serializable {
	
	private static final long serialVersionUID = -8383026023975718067L;

	private String username;
	
	private String name;
	
	private String status;

	public String getUsername() {
		return username;
	}

	public String getName() {
		return name;
	}

	public String getStatus() {
		return status;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setStatus(String status) {
		this.status = status;
	}
}

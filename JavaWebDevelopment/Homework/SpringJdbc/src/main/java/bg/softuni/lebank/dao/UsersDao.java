package bg.softuni.lebank.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.stereotype.Repository;

import bg.softuni.lebank.constants.DbParams;
import bg.softuni.lebank.interfaces.Users;
import bg.softuni.lebank.security.User;

@Repository
public class UsersDao implements Users {

	Map<String, User> Users;
	
	static {
		try {
			Class.forName(DbParams.DB_DRIVER);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public Map<String, User> getUsers() {
		this.populateUsers();
		
		return this.Users;
	}

	@Override
	public String[] getUsernames() {
		this.populateUsers();
		
		String[] usernames = null;
		Set<String> keys = this.Users.keySet();
		if (!this.Users.isEmpty()) {
			usernames = keys.toArray(new String[keys.size()]);
		}
		
		return usernames;
	}
	
	private void populateUsers() {		
		if (this.Users == null) {
			this.Users = new HashMap<String, User>();
		}
		
		try (
				Connection connection = DriverManager.getConnection(DbParams.URL, DbParams.USERNAME, DbParams.PASSWORD);
				Statement statement = connection.createStatement();) {
			String sql = "SELECT * FROM users";
			
			ResultSet result = statement.executeQuery(sql);
			
			while(result.next()) {
				String username = result.getString("username");
				String password = result.getString("password");
				String role = result.getString("role");

				User user = new User(username, password, this.makeAuthorities(role));
				
				if (this.Users.containsKey(username)) {
					this.Users.replace(username, user);
				} else {
					this.Users.put(username, user);
				}				
			}
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	
	private List<GrantedAuthority> makeAuthorities(String... roles) {
		List<GrantedAuthority> authorities = new ArrayList<>();
		for (String role : roles) {
			authorities.add(new SimpleGrantedAuthority(role));
		}
		
		return authorities;
	}
}

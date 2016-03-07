package bg.softuni.lebank.services;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.stereotype.Service;

import bg.softuni.lebank.interfaces.TestUsers;
import bg.softuni.lebank.security.User;

@Service
public class TestUsersRepository implements TestUsers {
	
	Map<String, User> testUsers;
	
	public TestUsersRepository() {
		// The password is "asd";
		String md5Password = "7815696ecbf1c96e6894b779456d330e";
		this.testUsers = new HashMap<>();
		this.testUsers.put(
				"user",
				new User("user", md5Password, mockthority("ROLE_USER")));
		this.testUsers.put(
				"employee",
				new User("employee", md5Password, mockthority("ROLE_USER", "ROLE_BANK_EMPLOYEE")));
	}
	
	@Override
	public Map<String, User> getUsers() {
		Object clonedUsers = ((HashMap<String, User>)this.testUsers).clone();
		return (Map<String, User>)clonedUsers;
	}
	
	@Override
	public String[] getUsernames() {
		String[] usernames = null;
		Set<String> keys = this.testUsers.keySet();
		if (!this.testUsers.isEmpty()) {
			usernames = keys.toArray(new String[keys.size()]);
		}
		
		return usernames;
	}
		
	private List<GrantedAuthority> mockthority(String... roles) {
		List<GrantedAuthority> authorities = new ArrayList<>();
		for (String role : roles) {
			authorities.add(new SimpleGrantedAuthority(role));
		}
		
		return authorities;
	}
}

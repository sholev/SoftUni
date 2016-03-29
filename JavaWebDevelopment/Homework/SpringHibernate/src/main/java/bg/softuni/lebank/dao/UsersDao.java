package bg.softuni.lebank.dao;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.hibernate.Criteria;
import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bg.softuni.lebank.entities.DatabaseUser;
import bg.softuni.lebank.interfaces.UsersStorage;
import bg.softuni.lebank.security.SecurityUser;

@Repository
public class UsersDao implements UsersStorage {

	@Autowired
	SessionFactory sessionFactory;
	
	Map<String, SecurityUser> Users;
	
	@Override
	public Map<String, SecurityUser> getUsers() {
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

	@Transactional
	private Boolean populateUsers() {		
		if (this.Users == null) {
			this.Users = new HashMap<String, SecurityUser>();
		}
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(DatabaseUser.class);		
		
		// This separation for the user classes is pretty bad,
		// and it will most likely cause trouble in the long run, 
		// however there is no long run for this homework. :)
		for (Object user : criteria.list()) {
			DatabaseUser dbUser = (DatabaseUser)user;
			
			SecurityUser newUser = 
					new SecurityUser(
							dbUser.getUsername(),
							dbUser.getPassword(),
							this.makeAuthorities(dbUser.getRole()));
			
			if (this.Users.containsKey(newUser.getUsername())) {
				this.Users.replace(newUser.getUsername(), newUser);
			} else {
				this.Users.put(newUser.getUsername(), newUser);
			}
		}		
		
		return true;
	}
	
	private List<GrantedAuthority> makeAuthorities(String... roles) {
		List<GrantedAuthority> authorities = new ArrayList<>();
		for (String role : roles) {
			authorities.add(new SimpleGrantedAuthority(role));
		}
		
		return authorities;
	}
}

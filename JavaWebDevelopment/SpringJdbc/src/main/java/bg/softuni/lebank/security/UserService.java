package bg.softuni.lebank.security;

import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

import bg.softuni.lebank.interfaces.UsersStorage;

public class UserService implements UserDetailsService {

	@Autowired
	UsersStorage users;
	
	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Map<String, User> users = this.users.getUsers();
		
		if (users.containsKey(username)) {
			return users.get(username);
		}
		
		return null;
	}
}

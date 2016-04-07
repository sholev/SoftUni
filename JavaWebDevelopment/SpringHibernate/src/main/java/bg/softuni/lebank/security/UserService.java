package bg.softuni.lebank.security;

import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import bg.softuni.lebank.interfaces.UserStorage;

@Service
public class UserService implements UserDetailsService {

	@Autowired
	UserStorage users;
	
	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Map<String, SecurityUser> users = this.users.getUsers();
		
		if (users.containsKey(username)) {
			return users.get(username);
		}
		
		return null;
	}
}

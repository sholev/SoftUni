package bg.softuni.library.security;

import java.util.List;
import java.util.Set;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

import bg.softuni.library.entity.user.User;
import bg.softuni.library.interfaces.RolesService;
import bg.softuni.library.interfaces.UsersService;

public class UsersSecurityService implements UserDetailsService {

	@Autowired
	UsersService users;
	
	@Autowired 
	RolesService roles;
	
	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Set<User> users = this.users.getUsers();

		User user = null;
		if (!users.isEmpty()) {
			user = users.stream()
			.filter(u -> u.getUsername().equals(username))
			.findFirst().get();
		}
		
		if (user != null) {			
			List<String> userRoles = roles.getRoles(user.getId());
			
			return new SecurityUser(
					user.getUsername(), 
					user.getPassword(),
					userRoles.toArray(new String[0]));
		}
		
		return null;
	}
}

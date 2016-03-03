package bg.softuni.lebank.security;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

public class UserService implements UserDetailsService {

	Map<String, User> presetUsers;
	
	public UserService() {
		// The password is "asd";
		String md5Password = "7815696ecbf1c96e6894b779456d330e";
		this.presetUsers = new HashMap<>();
		this.presetUsers.put(
				"normalUser",
				new User("normalUser", md5Password, mockthority("ROLE_USER")));
		this.presetUsers.put(
				"bankEmployee",
				new User("bankEmployee", md5Password, mockthority("ROLE_USER", "ROLE_EMPLOYEE")));
	}
	
	@Override
	public UserDetails loadUserByUsername(String username)
			throws UsernameNotFoundException {
		if (this.presetUsers.containsKey(username)) {
			return presetUsers.get(username);
		}
		
		return null;
	}
	
	private List<GrantedAuthority> mockthority(String... roles) {
		List<GrantedAuthority> authorities = new ArrayList<>();
		for (String role : roles) {
			authorities.add(new SimpleGrantedAuthority(role));
		}
		
		return authorities;
	}
}

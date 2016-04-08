package bg.softuni.library.utils.user;

import org.springframework.security.authentication.encoding.Md5PasswordEncoder;
import org.springframework.security.core.context.SecurityContextHolder;

import bg.softuni.library.entities.user.User;

public class UserUtils {

	public static User getUser() {
		Object principal;

		try {
			principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
		} catch (NullPointerException e) {
			return null;
		}

		if (principal == null || !(principal instanceof User)) {
			return null;
		}

		return (User) principal;
	}
		
	public static String getMd5FromString(String input) {
		Md5PasswordEncoder encoder = new Md5PasswordEncoder();
		return encoder.encodePassword(input, null);
	}
}
package bg.softuni.library.util;

import org.springframework.security.authentication.encoding.Md5PasswordEncoder;

public class SecurityUtil {
		
	public static String getMd5FromString(String input) {
		Md5PasswordEncoder encoder = new Md5PasswordEncoder();
		return encoder.encodePassword(input, null);
	}
}
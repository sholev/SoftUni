package bg.softuni.filters;

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 * Servlet Filter implementation class SecurityFilter
 */
@WebFilter("/*")
public class SecurityFilter implements Filter {

    /**
     * Default constructor. 
     */
    public SecurityFilter() {
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see Filter#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
	}

	/**
	 * @see Filter#doFilter(ServletRequest, ServletResponse, FilterChain)
	 */
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
		String username = "commanderShepard";
		String password = "doYouEvenHash";

		HttpServletRequest httpRequest = (HttpServletRequest)request;
		HttpServletResponse httpResponse = (HttpServletResponse)response;
		HttpSession session = httpRequest.getSession();
		
		String currentLocation = httpRequest.getRequestURL().toString();
		
		String inputUsername = (String)session.getAttribute("username");
		String inputPassword = (String)session.getAttribute("password");

		// Couldn't figure this out by the deadline :(
		if (currentLocation.contains("Login.html")) {
			if (inputUsername == username && inputPassword == password) {
				session.setAttribute("username", inputUsername);
				session.setAttribute("password", inputPassword);
				httpResponse.sendRedirect("HomePage");
			} else if (!currentLocation.contains("Login.html")) {
				httpResponse.sendRedirect("Login.html");
			}
		}
		
		
		System.out.println(inputUsername + " " + inputPassword);
		System.out.println(currentLocation);
		// pass the request along the filter chain
		chain.doFilter(request, response);
	}

	/**
	 * @see Filter#init(FilterConfig)
	 */
	public void init(FilterConfig fConfig) throws ServletException {
		// TODO Auto-generated method stub
	}

}

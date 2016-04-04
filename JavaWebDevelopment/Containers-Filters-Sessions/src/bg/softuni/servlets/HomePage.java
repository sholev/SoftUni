package bg.softuni.servlets;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 * Servlet implementation class homePage
 */
@WebServlet("/HomePage")
public class HomePage extends HttpServlet {
	private static final long serialVersionUID = 1L;
    
	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String username = request.getParameter("username");
        String password = request.getParameter("password");
		
		HttpSession session = request.getSession();	
		session.setAttribute("username", username);
		session.setAttribute("password", password);
		
		String separator = System.lineSeparator() + "<br>";
		String usernameHeader = "<h3>Username: " + (String)session.getAttribute("username")+ "</h3>";
		String header = "<h1>Homepage asd</h1>";
		String projectInfo = request.getContextPath() + " Version 1.0";
		
		String[] pageElements = new String[] {header, usernameHeader, projectInfo};
		
		String page = String.join(separator, pageElements);
		
		response.getWriter().append(page);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doGet(request, response);
	}

}

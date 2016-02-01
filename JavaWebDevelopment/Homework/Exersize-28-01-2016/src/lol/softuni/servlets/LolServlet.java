package lol.softuni.servlets;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class LolServlet
 */
@WebServlet("/LolServlet")
public class LolServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
     
	@Override
	public void service(ServletRequest request, ServletResponse response) throws IOException{
		HttpServletRequest httpRequest = (HttpServletRequest) request;
		String sessionId = httpRequest.getSession().getId();
		PrintWriter responseWriter = response.getWriter();
		
		httpRequest.getSession().setAttribute("testAttribute", "anotherTestAttribute");
		
		responseWriter.println(sessionId);
	}
	
	
}

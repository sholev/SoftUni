package bg.softuni;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.*;

/**
 * Servlet implementation class Table
 */
@WebServlet("/Table")
public class Table extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Table() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		Map<String, String> courses = new LinkedHashMap<String, String>();
		courses.put("Web Development Basics", "Date: 14 January 2016, 18:00-22:00 h.");
		courses.put("Servlets and Pages", "Date: 21 January 2016, 18:00-22:00 h.");
		courses.put("Containers, Filters and Sessions", "Date: 28 January 2016, 18:00-22:00 h.");		
		courses.put("Java Beans", "Date: 4 February 2016, 18:00-22:00 h.");
		courses.put("Spring Core", "Date: 11 February 2016, 18:00-22:00 h.");
		courses.put("Spring MVC", "Date: 18 February 2016, 18:00-22:00 h.");
		courses.put("Spring Security", "Date: 25 February 2016, 18:00-22:00 h.");
		courses.put("Oracle Database", "Date: 10 Match 2016, 18:00-22:00 h.");
		courses.put("Java Persistence", "Date: 17 Match 2016, 18:00-22:00 h.");
		courses.put("Final Test", "Date: 24 Match 2016, 18:00-22:00 h.");
		courses.put("Workshop - Building Web Application from Scratch", "Date: 31 Match 2016, 18:00-22:00 h.");
		courses.put("Project Presentations", "Date: 10 April 2016");
		
		response.getWriter().append("<table border=\"1\">");		
		courses.entrySet().forEach(entry -> {
				try {
					response.getWriter().append("<tr>");				
					response.getWriter()
						.append("<td>").append(entry.getKey()).append("</td>")
						.append("<td>").append(entry.getValue()).append("</td>");
					response.getWriter().append("</tr>");	
				} catch (IOException e) {
					// Not sure if I'm dumb, but why the hell does it force
					// me to catch this if the method already throws?
				}
		});
		response.getWriter().append("</table>");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}

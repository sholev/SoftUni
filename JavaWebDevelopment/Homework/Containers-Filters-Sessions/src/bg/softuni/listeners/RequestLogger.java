package bg.softuni.listeners;

import java.util.Date;

import javax.servlet.ServletRequest;
import javax.servlet.ServletRequestEvent;
import javax.servlet.ServletRequestListener;
import javax.servlet.annotation.WebListener;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

/**
 * Application Lifecycle Listener implementation class RequestLogger
 *
 */
@WebListener
public class RequestLogger implements ServletRequestListener {

	@Override
	public void requestDestroyed(ServletRequestEvent request) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void requestInitialized(ServletRequestEvent request) {
		ServletRequest servletRequest = request.getServletRequest();		
		HttpServletRequest httpServletRequest = (HttpServletRequest)servletRequest;
		HttpSession session = httpServletRequest.getSession();
		
		String ipAddress = servletRequest.getRemoteAddr();
		String sessionId = session.getId();		
		// TODO: figure out how to get if it is a normal request or login type.
		String contentType = servletRequest.getDispatcherType().toString();
		String date = new Date().toString();
		
		System.out.println("ipAddress: " + ipAddress);
		System.out.println("sessionId: " + sessionId);
		System.out.println("contentType: " + contentType);
		System.out.println("date: " + date);
	}
	
}

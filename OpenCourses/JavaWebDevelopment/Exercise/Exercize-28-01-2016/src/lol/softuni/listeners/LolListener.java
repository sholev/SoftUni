package lol.softuni.listeners;

import javax.servlet.annotation.WebListener;
import javax.servlet.http.HttpSessionActivationListener;
import javax.servlet.http.HttpSessionAttributeListener;
import javax.servlet.http.HttpSessionBindingEvent;
import javax.servlet.http.HttpSessionBindingListener;
import javax.servlet.http.HttpSessionEvent;
import javax.servlet.http.HttpSessionIdListener;
import javax.servlet.http.HttpSessionListener;

/**
 * Application Lifecycle Listener implementation class LolListener
 *
 */
@WebListener
public class LolListener implements HttpSessionListener{

	@Override
	public void sessionCreated(HttpSessionEvent sessionEvent) {
		String sessionId = sessionEvent.getSession().getId();
		
		//System.out.println(sessionId);
		
	}

	@Override
	public void sessionDestroyed(HttpSessionEvent sessionEvent) {
		// TODO Auto-generated method stub
		
	}
	
}

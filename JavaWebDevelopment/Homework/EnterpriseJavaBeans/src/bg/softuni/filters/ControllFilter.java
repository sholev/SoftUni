package bg.softuni.filters;

import java.io.IOException;

import javax.ejb.EJB;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;

import bg.softuni.ejb.model.BankingAccount;

@WebFilter("/*")
public class BankingPageFilter implements Filter {
	
	private final String version = "1.0";
	private final String project = "Banking Page Homework";

	// I understand that the EJB should be handled by the container
	// and I shouldn't initialize it, however for some reason
	// it is staying null and I'm getting null pointer exception.
	// This is why I will initialize it for now, and try to figure it out later.
	@EJB
	private BankingAccount bankingAccount = new BankingAccount();
	
	public void destroy() {
	}
	
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) 
			throws IOException, ServletException {
				
		String version = (String)request.getAttribute("version");
		String project = (String)request.getAttribute("project");
				
		if (version == null){			
			request.setAttribute("version", this.version);			
		}
		if (project == null){			
			request.setAttribute("project", this.project);			
		}

		String output = null;
		String userId = (String)request.getAttribute("userId");
		String user = request.getParameter("userId");
		if (userId == null && user != ""){			
			request.setAttribute("userId", user);
			userId = user;
		}
		
		if (userId != null && !userId.contains(" ")) {
			String action = request.getParameter("action");
			String amount = request.getParameter("amount");
			
			if (action != null && action.equals("deposit")){
				output = this.bankingAccount.Deposit(userId, amount);
			} else if (action != null && action.equals("withdraw")){
				output = this.bankingAccount.Withdraw(userId, amount);
			} else {
				output = "Deposit or withdrawal wasn't selected.";
			}
			
			String balance = bankingAccount.getAccountBallance(userId);	
			request.setAttribute("balance", balance);
		} else {
			output = "Enter valid id, no whitespace allowed:";
		}
		
		request.setAttribute("output", output);
		
		chain.doFilter(request, response);
	}
	
	public void init(FilterConfig fConfig) throws ServletException {
		// TODO Auto-generated method stub
	}

}

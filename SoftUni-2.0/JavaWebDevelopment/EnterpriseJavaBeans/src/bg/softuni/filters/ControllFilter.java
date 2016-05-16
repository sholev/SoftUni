package bg.softuni.filters;

import java.io.IOException;
import java.time.LocalDateTime;

import javax.ejb.EJB;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;

import bg.softuni.ejb.model.BankingAccounts;
import bg.softuni.ejb.model.BgnExchangeRates;

@WebFilter("/BankingPage.jsp")
public class ControllFilter implements Filter {
	
	private final String version = "Version: 1.1";
	private final String project = "Project: Banking Page Homework";

	// I understand that the EJB should be handled by the container
	// and I shouldn't initialize it, however for some reason
	// it is staying null and I'm getting null pointer exception.
	@EJB
	private BankingAccounts bankingAccounts = new BankingAccounts();
	@EJB
	private BgnExchangeRates bgnRates = new BgnExchangeRates();
	
	public void destroy() {
	}
	
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) 
			throws IOException, ServletException {
		
		LocalDateTime now = LocalDateTime.now();
		request.setAttribute("date", " Date:" + now.toLocalDate() + " Time:" + now.toLocalTime());
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
		String inputUser = request.getParameter("userId");
		if (userId == null && inputUser != ""){			
			request.setAttribute("userId", inputUser);
			userId = inputUser;
		}
		
		if (userId != null && !userId.contains(" ")) {
			String action = request.getParameter("action");
			String amount = request.getParameter("amount");
			String currency = request.getParameterValues("currency")[0];
			
			if (action != null && action.equals("deposit")){
				output = this.bankingAccounts.deposit(userId, amount, currency, bgnRates);
			} else if (action != null && action.equals("withdraw")){
				output = this.bankingAccounts.withdraw(userId, amount, currency, bgnRates);
			} else {
				output = "Deposit or withdrawal wasn't selected.";
			}
			
			String balance = bankingAccounts.getAccountBallance(userId);	
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

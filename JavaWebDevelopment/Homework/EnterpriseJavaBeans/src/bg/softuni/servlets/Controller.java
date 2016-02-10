package bg.softuni.servlets;

import java.io.IOException;

import javax.ejb.EJB;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bg.softuni.ejb.model.BankingAccount;

@WebServlet("/Submit")
public class Controller extends HttpServlet {
	private static final long serialVersionUID = 637133710L;

	@EJB
	private BankingAccount bankingAccount;
	
    public Controller() {
        super();
    }
    
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
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
			output = "Enter valid id:";
		}
		
		request.setAttribute("output", output);
		
		response.sendRedirect("/EnterpriseJavaBeans/BankingPage.jsp");
	}
	
	protected void doPost(HttpServletRequest request, HttpServletResponse response) 
			throws ServletException, IOException {
		
		doGet(request, response);
	}
}

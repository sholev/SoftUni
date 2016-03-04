package bg.softuni.lebank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.UserAccounts;

@Controller
public class BankingController {
	
	@Autowired
	private UserAccounts userAccounts;
	
	@Autowired
	private AccountsRepository accountsRepository;
	
	@RequestMapping(value = {"/", "/registry"})
	public String registry(Model model) {
		
		String output = "Your banking information:";
		
		String username = SecurityContextHolder.getContext().getAuthentication().getName();			
		model.addAttribute("accountUsername", username);	
		
		// TODO: Facade this.
		String[] accountIds = this.userAccounts.getIds(username);		
		String[] ballancePerId = this.accountsRepository.getMultipleAccountsBallance(accountIds);		
		String[] currencyPerId = this.accountsRepository.getMultipleAccountsCurrency(accountIds);
		DisplayData[] displayData = new DisplayData[accountIds.length];		
		for	(int i = 0; i < displayData.length; i++) {
			displayData[i] = new DisplayData(accountIds[i], ballancePerId[i], currencyPerId[i]);
		}
		if (displayData.length == 1 && displayData[0].getAccountId().equals(""))
		{
			displayData[0].setAccountBallance("");
			output = "No banking accounts available.";
		}
		model.addAttribute("displayData", displayData);

		model.addAttribute("output", output);
		return "registry";
	}
	
	@RequestMapping(value = "/operation")
	public String operation(Model model) {	
		
		return "operation";
	}
	
	@RequestMapping(value = "/newAccount")
	public String newAccount(Model model) {	
		
		return "newAccount";
	}
}

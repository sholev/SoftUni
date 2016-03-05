package bg.softuni.lebank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.entities.NewAccountInput;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.UserAccounts;

@Controller
public class BankingController {
	
	// TODO: Separate POST and GET request in different methods.
	
	@Autowired
	private UserAccounts userAccounts;
	
	@Autowired
	private AccountsRepository accountsRepository;
	
	@RequestMapping(value = {"/", "/registry"})
	public String registry(Model model) {
		String username = SecurityContextHolder.getContext().getAuthentication().getName();	
		String boldUsername = "<b>" + username + "</b>";
		//model.addAttribute("accountUsername", username);	
		String output = "Banking information for client \"" + boldUsername + "\":";
		
		// TODO: Facade this.
		String[] accountIds = this.userAccounts.getIds(username);	
		DisplayData[] displayData = null;
		if (accountIds != null) {
			String[] ballancePerId = this.accountsRepository.getMultipleAccountsBallance(accountIds);		
			String[] currencyPerId = this.accountsRepository.getMultipleAccountsCurrency(accountIds);
			displayData = new DisplayData[accountIds.length];		
			for	(int i = 0; i < displayData.length; i++) {
				displayData[i] = new DisplayData(accountIds[i], ballancePerId[i], currencyPerId[i]);
			}			
		} else {
				output = "Client \"" + boldUsername + "\" has no banking accounts available.";
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
	public String newAccount(Model model, @ModelAttribute(value = "SpringWeb") NewAccountInput input) {
		String output = "Enter information for the new account.";
		String username = SecurityContextHolder.getContext().getAuthentication().getName();
		
		String[] accountIds = this.userAccounts.getIds(username);
		int accountNumber = accountIds == null ? 1 : accountIds.length + 1;
		model.addAttribute("accountNumber", accountNumber);
		
		String initialBallance = input.getInitialBallance();
		String initialCurrency = input.getInitialCurrency();
		String accountKey = username + "-" + accountNumber;
		if (initialBallance == "") {
			output = "Initial ballance should not be empty.";
		} else if (initialBallance != null) {
			output = this.accountsRepository.deposit(accountKey, initialBallance, initialCurrency);
			this.userAccounts.add(username, accountKey);	 
		}
		
		model.addAttribute("output", output);
		if (output.contains(OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER)) {
			return this.registry(model);
		}
		
		return "newAccount";
	}
}

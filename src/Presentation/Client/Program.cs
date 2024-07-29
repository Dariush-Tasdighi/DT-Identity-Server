using System;
using Persistence;
using System.Linq;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using Domain.Features.Identity.Companies;
using Domain.Features.Identity.Applications;

{
	using var applicationDbContext = new ApplicationDbContext();

	var username = new Username(value: "Dariush");
	var password = new Password(value: "1234512345");
	var emailAddress = new EmailAddress(value: "DariushT@GMail.com");

	var user =
		new User(username: username, password: password, emailAddress: emailAddress);

	applicationDbContext.Add(entity: user);

	await applicationDbContext.SaveChangesAsync();

	var companyName = new Name(value: "MyCompany");
	var companyTitle = new Title(value: "My Company");

	var company =
		new Company(userId: user.Id, name: companyName, title: companyTitle);

	applicationDbContext.Add(entity: company);

	await applicationDbContext.SaveChangesAsync();

	var applicationName = new Name(value: "MyApplication");
	var applicationTitle = new Title(value: "My Application");

	var application =
		new Application(companyId: company.Id, name: applicationName, title: applicationTitle);

	applicationDbContext.Add(entity: application);

	// نباید دستور ذیل را بنویسیم
	//await applicationDbContext.SaveChangesAsync();

	var userValidIP4_1 = "1.1.1.1";
	var userValidIP4_2 = "2.2.2.2";
	var userValidIP4_3 = "1.1.1.1";

	application.AddUserValidIP(ip: userValidIP4_1);
	application.AddUserValidIP(ip: userValidIP4_2);
	application.AddUserValidIP(ip: userValidIP4_3);

	var applicationValidIP4_1 = "3.3.3.3";
	var applicationValidIP4_2 = "4.4.4.4";
	var applicationValidIP4_3 = "3.3.3.3";

	application.AddApplicationValidIP(ip: applicationValidIP4_1);
	application.AddApplicationValidIP(ip: applicationValidIP4_2);
	application.AddApplicationValidIP(ip: applicationValidIP4_3);

	await applicationDbContext.SaveChangesAsync();
}

{
	using var applicationDbContext = new ApplicationDbContext();

	var username =
		new Username(value: "Dariush");

	var theUser =
		await
		applicationDbContext.Users

		.Include(current => current.Companies)
		.ThenInclude(current => current.Applications)
		.ThenInclude(current => current.UserValidIPs)

		.Include(current => current.Companies)
		.ThenInclude(current => current.Applications)
		.ThenInclude(current => current.ApplicationValidIPs)

		.Where(current => current.Username == username)
		.FirstOrDefaultAsync();

	if (theUser is not null)
	{
		var companyCount =
			theUser.Companies.Count();
	}
}

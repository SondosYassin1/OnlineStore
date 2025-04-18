//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using OnlineStore.Models;

//namespace OnlineStore.Area.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class UserManagementController : Controller
//    {
//        private readonly UserManager<ApplicationUser> userManager;
//        private readonly RoleManager<IdentityRole> roleManager;

//        public UserManagementController(
//            UserManager<ApplicationUser> userManager,
//            RoleManager<IdentityRole> roleManager)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//        }

//        public async Task<IActionResult> IndexAsync()
//        {
//            var users = await userManager.Users.ToListAsync();
//            var userViewModels = new List<UserViewModel>();
//        }


//        [HttpGet]
//        // GET: /Admin/UserManagement/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var user = await userManager.FindByIdAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            // Get user's current roles
//            var userRoles = await userManager.GetRolesAsync(user);

//            // Get all available roles
//            var roles = roleManager.Roles.Select(r => new SelectListItem
//            {
//                Text = r.Name,
//                Value = r.Name,
//                Selected = userRoles.Contains(r.Name)
//            }).ToList();

//            var viewModel = new UserRoleViewModel
//            {
//                UserId = user.Id,
//                UserName = user.Email,
//                Roles = roles,
//                SelectedRoles = userRoles.ToArray()
//            };

//            return View(viewModel);

//            // POST: /Admin/UserManagement/Edit
//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            public async Task<IActionResult> Edit(UserRoleViewModel model)
//            {
//                var user = await userManager.FindByIdAsync(model.UserId);
//                if (user == null)
//                {
//                    return NotFound();
//                }

//                // Get current roles
//                var currentRoles = await userManager.GetRolesAsync(user);

//                // Check if attempting to remove Admin role from current user
//                if (User.Identity.Name == user.Email &&
//                   currentRoles.Contains("Admin") &&
//                    (model.SelectedRoles == null || !model.SelectedRoles.Contains("Admin")))
//                {
//                    TempData["ErrorMessage"] = "You cannot remove yourself from the Admin role.";
//                    return RedirectToAction(nameof(Index));
//                }

//                // Get selected roles from the form
//                var selectedRoles = model.SelectedRoles ?? new string[] { };

//                // Remove user from roles that weren't selected
//                var rolesToRemove = currentRoles.Except(selectedRoles);
//                if (rolesToRemove.Any())
//                {
//                    var removeResult = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
//                    if (!removeResult.Succeeded)
//                    {
//                        ModelState.AddModelError("", "Failed to remove user from some roles");
//                        return View(model);
//                    }
//                }

//                // Get selected roles from the form
//                var selectedRoles = model.SelectedRoles ?? new string[] { };

//                // Remove user from roles that weren't selected
//                var rolesToRemove = currentRoles.Except(selectedRoles);
//                if (rolesToRemove.Any())
//                {
//                    var removeResult = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
//                    if (!removeResult.Succeeded)
//                    {
//                        ModelState.AddModelError("", "Failed to remove user from some roles");
//                        return View(model);
//                    }
//                }

//                // Add user to roles that were selected but user isn't in yet
//                var rolesToAdd = selectedRoles.Except(currentRoles);
//                if (rolesToAdd.Any())
//                {
//                    var addResult = await userManager.AddToRolesAsync(user, rolesToAdd);
//                    if (!addResult.Succeeded)
//                    {
//                        ModelState.AddModelError("", "Failed to add user to some roles");
//                        return View(model);
//                    }
//                }

//                TempData["SuccessMessage"] = "User roles updated successfully.";
//                return RedirectToAction(nameof(Index));
//            }
//        }
//    }
//}

﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApplication.Dialogs;
using ToDoApplication.Repositories;
using ToDoApplication.ViewModels;

namespace ToDoApplication.Services
{
	internal class DialogService : IDialogService
	{
		private ITagRepository _tagRepository;
		public DialogService(ITagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}
		public void ShowManageTagsDialog(ObservableCollection<ToDoItemTagsViewModel> tags,IEnumerable<Guid> refernceIds) 
		{
			var managetagsDialog = new ManageTagsDialog();
			managetagsDialog.DataContext = new ManageTagsDialogViewModel(tags, refernceIds,this, _tagRepository);
			SetDialogHostContent(managetagsDialog);
		}

		public void ShowErrorDialog(string message)
		{
			var errorDialog = new ErrorDialog();

			errorDialog.DataContext = message;

			SetDialogHostContent(errorDialog);
		}

		private static void SetDialogHostContent(object content)
		{
			DialogHost.Show(content);
		}
	}
}

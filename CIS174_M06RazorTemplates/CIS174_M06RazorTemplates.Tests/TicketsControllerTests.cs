namespace CIS174_M06RazorTemplates.Tests
{
    public class TicketsControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var rep = new Mock<ITicketRepository>();
            rep.Setup(m => m.List())
                .Returns(new List<Ticket>());

            var controller = new TicketsController(rep.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ReturnsTicketList()
        {
            var tickets = new List<Ticket>
            {
                new Ticket()
            };

            var rep = new Mock<ITicketRepository>();
            rep.Setup(m => m.List()).Returns(tickets);

            var controller = new TicketsController(rep.Object);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(tickets, result.Model);
        }

        [Fact]
        public void Add_POST_ReturnsRedirectIfModelIsValid()
        {
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketsController(rep.Object);

            var ticket = new Ticket();

            var result = controller.Add(ticket);

            Assert.IsType<RedirectToActionResult>(result);
            rep.Verify(m => m.Add(ticket), Times.Once);
            rep.Verify(m => m.Save(), Times.Once);
        }

        [Fact]
        public void Add_POST_ReturnsViewIfModelIsInvalid()
        {
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketsController(rep.Object);

            controller.ModelState.AddModelError(
                "Name", "Name is required.");

            var ticket = new Ticket();

            var result = controller.Add(ticket);

            Assert.IsType<ViewResult>(result);
            rep.Verify(m => m.Add(It.IsAny<Ticket>()), Times.Never);
            rep.Verify(m => m.Save(), Times.Never);
        }

        [Fact]
        public void UpdateStatus_ReturnsRedirectToIndex()
        {
            var ticket = new Ticket { Id = 1, Status = "To Do" };

            var rep = new Mock<ITicketRepository>();
            rep.Setup(m => m.Get(1)).Returns(ticket);

            var controller = new TicketsController(rep.Object);

            var result = controller.UpdateStatus(1, "Done");

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Done", ticket.Status);
            rep.Verify(m => m.Save(), Times.Once);
        }

        [Fact]
        public void Delete_ReturnsRedirectToIndex()
        {
            var ticket = new Ticket { Id = 1 };

            var rep = new Mock<ITicketRepository>();
            rep.Setup(m => m.Get(1)).Returns(ticket);

            var controller = new TicketsController(rep.Object);

            var result = controller.Delete(1);

            Assert.IsType<RedirectToActionResult>(result);
            rep.Verify(m => m.Delete(ticket), Times.Once);
            rep.Verify(m => m.Save(), Times.Once);
        }
    }
}
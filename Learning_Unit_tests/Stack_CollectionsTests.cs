using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class Stack_CollectionsTests
    {

        [Test]
        public void PropretyCount_EmptyStack_ReturnZero()
        {
            var stack = new Stack_Collections<string>();

            Assert.That(stack.Count, Is.Zero);
        }

        [Test]
        public void PropretyCount_WhenRemovedAnElement_ReturnZero()
        {
            var stack = new Stack_Collections<string>();
            stack.Push("a");
            stack.Pop();

            Assert.That(stack.Count, Is.Zero);
        }

        [Test]
        public void PropretyCount_WhenNotRemovedAnElement_ReturnCountStack()
        {
            var stack = new Stack_Collections<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            
            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(4));
        }

        [Test]
        public void StackPush_AddsANullObjectToTheQueue_ThrowArgumentNullException()
        {
            var stack = new Stack_Collections<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void StackPush_ValidArg_AddObjectToTheQueue()
        {
            var stack = new Stack_Collections<string>();
            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void StackPop_WhenTheCollectionIsEmpty_ThrowInvalidOperationException()
        {
            var stack = new Stack_Collections<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);

        }

        [Test]
        public void StackPop_WhenTheCollectionIsNotEmpty_ReturnTheDataRemoved()
        {
            var stack = new Stack_Collections<string>();
            stack.Push("a");
            
            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("a"));

        }

        [Test]
        public void StackPeek_WhenTheCollectionIsEmpty_ThrowInvalidOperationException()
        {
            var stack = new Stack_Collections<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);

        }

        [Test]
        public void StackPeek_WhenTheCollectionIsNotEmpty_ReturnTheData()
        {
            var stack = new Stack_Collections<string>();
            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("b"));

        }
    }
}
